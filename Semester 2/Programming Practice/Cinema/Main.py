import uuid
import datetime


class CinemaException(Exception):
    def __init__(self, text):
        self.txt = text


class Host:
    def __init__(self, cinema, stall):
        self.id = uuid.uuid4()
        self.stall = stall
        self.cinemas = {cinema.name: cinema}

    def add_cinema(self, cinema):
        self.cinemas[cinema.name] = cinema

    def remove_cinema(self, cinema_name):
        self.cinemas.pop(cinema_name)

    def add_session(self, session, stall):
        try:
            stall.add_session(self, session)
        except CinemaException:
            print('Невозможно добавить данную сессию')

    def get_sessions_list(self):
        return stall.get_host_sessions(self)

    def display_free_halls(self, start_date, end_date):
        self.stall.display_free_halls(self, start_date, end_date)


class Client:
    def __init__(self, stall):
        self.stall = stall
        self.id = uuid.uuid4()
        self.tickets = list()

    def buy_ticket(self, session, row, seat):
        try:
            self.stall.sell_ticket(session, row, seat)
            self.tickets.append((session, (row, seat)))
        except CinemaException as ex:
            if ex == "OccupiedSeatException":
                print("Такого места нет!")
            else:
                print("Это место занято!")

    def return_ticket(self, ticket):
        session = ticket[0]
        row = ticket[1][0]
        seat = ticket[1][1]
        if ticket not in self.tickets:
            print("У вас нет такого билета!")
            return
        try:
            self.stall.return_ticket(session, row, seat)
            self.tickets.remove(ticket)
        except CinemaException:
            print("Данный билет не действителен")

    def display_schedule(self):
        self.stall.display_schedule()

    def display_specified_session(self, name, seats_nearby = 1):
        self.stall.display_specified_session(name, seats_nearby)


class Stall:
    def __init__(self):
        self.schedule = dict()

    def add_host(self, host):
        self.host = host

    def add_session(self, host, new_session):
        for host_sessions in self.schedule.values():
            for session in host_sessions:
                if not (session.end < new_session.start
                        or new_session.end < session.start
                        or new_session.start != session.start):
                    raise CinemaException("AddSessionException")
        if host.id in self.schedule.keys():
            self.schedule[host.id].append(new_session)
        else:
            self.schedule[host.id] = [new_session]
        self.schedule[host.id].sort(key=lambda x: x.start)

    def get_host_sessions(self, host):
        return self.schedule[host.id]

    def remove_session(self, host, session):
        self.schedule[host.id].remove(session)

    def sell_ticket(self, session, row, seat):
        if session.get_seat_state(row, seat):
            session.change_seat_state(row, seat, False)
        else:
            raise CinemaException("OccupiedSeatException")

    def return_ticket(self, session, row, seat):
        if session.state and not session.get_seat_state(row, seat):
            session.change_seat_state(row, seat, True)
        else:
            raise CinemaException("DefuncTicketException")

    def display_schedule(self):
        for host in self.schedule.values():
            for session in host:
                print(session.get_general_information())

    def display_specified_session(self, name, seats_nearby):
        for hosts_sessions in self.schedule.values():
            for session in hosts_sessions:
                if session.name == name and session.have_seats_nearby(seats_nearby):
                    print(session.get_general_information())
                    print('План зала:')
                    session.display_seat_configuration()


class Session:
    def __init__(self, name, start, duration, host, cinema_name, hall_name):
        self.state = True
        self.name = name
        self.start = start
        self.duration = duration
        self.end = start + duration
        self.host = host
        self.cinema_name = cinema_name
        self.hall_name = hall_name
        self.seats_state = dict()
        seats = host.cinemas[cinema_name].halls[hall_name].seats
        for row in seats.keys():
            self.seats_state[row] = {seat:True for seat in seats[row]}

    def get_general_information(self):
        return 'name={}, begin={}, duration={}, cinema={}, hall={}'.format(
            self.name, self.start, self.duration, self.cinema_name, self.hall_name)

    def change_seat_state(self, row, seat, value):
        self.seats_state[row][seat] = value

    def get_seat_state(self, row, seat):
        return self.seats_state[row][seat]

    def display_seat_configuration(self):
        for row in self.seats_state.values():
            for seat in row.keys():
                if row[seat]:
                    print('\033[32m{}'.format(seat), end='\t')
                else:
                    print('\033[31m{}'.format(seat), end='\t')
            print()
        print('\033[0m')


    def is_not_full(self):
        return self.have_seats_nearby(1)

    def have_seats_nearby(self, amount_seats):
        for row in self.seats_state.values():
            seats_nearby = 0
            for seat in row.keys():
                if row[seat]:
                    seats_nearby += 1
                    if seats_nearby >= amount_seats:
                        return True
                else:
                    seats_nearby = 0
        return False


class Cinema:
    def __init__(self, name, hall):
        self.name = name
        self.halls = {hall.name: hall}

    def get_seats_config(self, hall_name):
        return self.halls[hall_name].seats

    def add_hall(self, hall):
        self.halls[hall.name] = hall

    def remove_hall(self, hall_name):
        self.halls.pop(hall_name)


class Hall:
    def __init__(self, name, seats):
        self.name = name
        self.seats = seats

    def set_seat_configuration(self, seats):
        self.seats = seats


# Seats
seats = {i: [j for j in range(1, 10)] for i in range(1, 10)}

# Halls
hall_1 = Hall('1', seats)
hall_2 = Hall('2', seats)
hall_3 = Hall('3', seats)
hall_4 = Hall('4', seats)
hall_5 = Hall('5', seats)
hall_6 = Hall('6', seats)

# Cinemas
cinema_1 = Cinema("Коралл", hall_1)
cinema_1.add_hall(hall_2)
cinema_1.add_hall(hall_3)
cinema_1.add_hall(hall_4)
cinema_2 = Cinema("Октябрь", hall_5)
cinema_2.add_hall(hall_6)

# Host and Stall
stall = Stall()
kaban = Host(cinema_1, stall)
kaban.add_cinema(cinema_2)

# Sessions
session_1 = Session("Movie", datetime.datetime(2023,3,16,18,30), datetime.timedelta(minutes=120), kaban,
                    cinema_1.name, hall_1.name)
session_2 = Session("Movie", datetime.datetime(2023,4,16,19,30), datetime.timedelta(minutes=130), kaban,
                    cinema_1.name, hall_3.name)
session_3 = Session("Movie", datetime.datetime(2023,4,16,18,30), datetime.timedelta(minutes=110), kaban,
                    cinema_1.name, hall_2.name)
session_4 = Session("Movie", datetime.datetime(2023,4,16,10,30), datetime.timedelta(minutes=120), kaban,
                    cinema_2.name, hall_6.name)
session_5 = Session("Movie", datetime.datetime(2023,4,16,13,30), datetime.timedelta(minutes=140), kaban,
                    cinema_2.name, hall_5.name)
session_6 = Session("Movie", datetime.datetime(2023,4,16,17,30), datetime.timedelta(minutes=120), kaban,
                    cinema_2.name, hall_6.name)

# Client
Artur = Client(stall)

kaban.add_session(session_1, stall)
kaban.add_session(session_2, stall)
kaban.add_session(session_3, stall)
kaban.add_session(session_4, stall)
kaban.add_session(session_5, stall)
kaban.add_session(session_6, stall)

Artur.buy_ticket(session_6, 3, 4)

def display_cinemas(host):
    i = 1
    cinemas = {}
    for cinema_name in host.cinemas:
        print(str(i) + '. ' + cinema_name)
        cinemas[str(i)] = cinema_name
        i += 1
    return cinemas


def display_halls(cinema):
    i = 1
    halls = {}
    for hall_name in cinema.halls.keys():
        print(str(i) + '. ' + hall_name)
        halls[str(i)] = hall_name
        i+=1
    return halls


while True:
    print('\n\n\n')
    print('Кто вы?\n'
          '1. Владелец\n'
          '2. Клиент')
    message = input()

    if message == '1':
        print('1. Добавить кинотеатр\n'
              '2. Удалить кинотеатр\n'
              '3. Добавить зал\n'
              '4. Удалить зал\n'
              '5. Добавить сеанс'
              )
        message = input()

        if message == '1':
            print('Сначала нужно создать зал, укажите расположение сидений\n'
                  '1. Использовать стандартное\n'
                  '2. Задать своё')

            if input() == 2:
                pass

            print('Укажите имя зала:')

            new_hall = Hall(input(), seats)
            print('Укажите имя кинотеатра')
            kaban.add_cinema(Cinema(input(), new_hall))

        elif message == '2':
            print('Укажите кинотеатр')
            cinemas = display_cinemas(kaban)
            try:
                cinema_name = cinemas[input()]
            except KeyError:
                print('Такого кинотеатра нет!')
                break
            kaban.remove_cinema(cinema_name)

        elif message == '3':
            print('В какой кинотеатр вы хотите добавить зал?')
            i = 1
            cinemas = display_cinemas(kaban)

            message = input()
            try:
                cinema_name = cinemas[message]
            except KeyError:
                print('Кинотеатра {} не существует'.format(message))
                continue

            print('Укажите расположение сидений\n'
                  '1. Использовать стандартное\n'
                  '2. Задать своё')

            if input() == 2:
                pass

            print('Укажите имя зала:')

            new_hall = Hall(input(), seats)
            kaban.cinemas[cinema_name].add_hall(new_hall)

        elif message == '4':
            print('Выберите кинотеатр')
            cinemas = display_cinemas(kaban)
            try:
                cinema_name = cinemas[input()]
            except KeyError:
                print('Такого кинотеатра нет!')
                break
            print('Укажите зал')
            halls = display_halls(kaban.cinemas[cinema_name])
            try:
                hall_name = halls[input()]
            except KeyError:
                print('Такого зала нет!')
                break

        elif message == '5':
            print('Укажите название фильма')
            name = input()
            print("Укажите начало фильма yyyy/mm/dd hh:mm")
            message = input().split()
            date = list(map(int, message[0].split('/')))
            time = list(map(int, message[1].split(':')))
            new_date = datetime.datetime(date[0],date[1],date[2], time[0], time[1])
            print('Укажите длительность фильма в минутах')
            duration = datetime.timedelta(minutes=int(input()))

            print('Укажите кинотеатр')
            cinemas = display_cinemas(kaban)
            try:
                cinema_name = cinemas[input()]
            except KeyError:
                print('Такого кинотеатра нет!')
                break
            print('Укажите зал')
            halls = display_halls(kaban.cinemas[cinema_name])
            try:
                hall_name = halls[input()]
            except KeyError:
                print('Такого зала нет!')
                break
            new_session = Session(name,new_date, duration, kaban, cinema_name, hall_name)
            kaban.add_session(new_session, stall)

    elif message == '2':
        print('1. Посмотреть расписание\n'
              '2. Посмотреть ближайшую дату показа интересующего вас фильма\n'
              '3. Купить билет\n'
              '4. Вернуть билет\n')
        message = input()
        if message == '1':
            Artur.display_schedule()
        elif message == '2':
            print('Укажите название фильма')
            name = input()
            print('Сколько свободных мест должно быть рядом?')
            Artur.display_specified_session(name, int(input()))
        elif message == '3':
            print("Выберите интересующий вас сеанс")
            counter = 1
            for session in kaban.get_sessions_list():
                print(str(counter) + '.', session.get_general_information())
                counter+=1
            message = int(input())
            session = kaban.get_sessions_list()[message-1]
            print("Выберите ряд и место (пример: 3 4):")
            session.display_seat_configuration()
            row, seat = map(int, input().split())
            Artur.buy_ticket(session, row, seat)

        elif message == '4':
            if not len(Artur.tickets):
                print("У вас нет билетов!")
                continue
            print("Выберите билет, который хотите вернуть:")
            counter = 1
            for ticket in Artur.tickets:
                session = ticket[0]
                row = ticket[1][0]
                seat = ticket[1][1]
                print("{}. movie={}, begin={}, cinema={}, hall={} row={}, seat={}".format(counter, session.name,
                      session.start, session.cinema_name, session.hall_name, row, seat))
            message = int(input())
            Artur.return_ticket(Artur.tickets[message-1])


