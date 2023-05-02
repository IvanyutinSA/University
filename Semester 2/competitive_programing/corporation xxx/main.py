class Employee:
    def __init__(self, id, name=""):
        self.id = id
        self.name = name
        self.subordinates = list()

    def add_subordinate(self, subordinate):
        self.subordinates.append(subordinate)

    def __str__(self):
        return self.id + ' ' + self.name


def input_and_add(employees: dict, line):
    id = line.pop(0)
    if line:
        name = ' '.join(line)
    else:
        name = 'Unknown Name'
    if id in employees.keys():
        if employees[id].name == 'Unknown Name':
            employees[id].name = name
    else:
        employees[id] = Employee(id, name)
    return employees[id]


f = open('corporation xxx/input_s1_06.txt')

employees = dict()
line = f.readline().split()
while line[0] != "END":
    employer = input_and_add(employees, line)
    employee = input_and_add(employees, f.readline().split())
    employer.add_subordinate(employee)
    line = f.readline().split()

things = f.readline().split()

try:
    thing = int(things[0])
    thing = things[0]
except:
    thing = ' '.join(things)

for employee in employees.values():
    if employee.name == thing or employee.id == thing:
        body = employee
        break

bodies = list()
stack = [body]
while stack:
    body = stack.pop()
    subordinates = body.subordinates
    bodies.append(body)
    if not subordinates:
        pass
    else:
        for employee in subordinates:
            stack.append(employee)

bodies.pop(0)
bodies.sort(key=lambda x: x.id)
for man in bodies:
    print(man)
if not bodies:
    print('NO')
