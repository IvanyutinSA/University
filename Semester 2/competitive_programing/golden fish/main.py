def get_weighted_words(
        words: list[tuple],
        first_letters: dict[str, int],
        last_letters: dict[str, int],
) -> list[tuple]:
    weighted_words = list()
    for word in words:
        try:
            if first_letters[word[0]] and last_letters[word[1]]:
                weighted_words.append((
                    word,
                    min(first_letters[word[0]], last_letters[word[1]]),
                ))
        except KeyError:
            continue
    return weighted_words


f = open('GoldenFish/input_s1_12.txt')

words = list()

for i in range(int(f.readline())):
    word = f.readline()

    words.append(
        (word[0], word[-2])
    )

first_letters = dict()

for i in range(int(f.readline())):
    line = f.readline().split()
    first_letters[line[0]] = int(line[1])

last_letters = dict()

for i in range(int(f.readline())):
    line = f.readline().split()
    last_letters[line[0]] = int(line[1])


wish_fulfills = 0

while True:
    weighted_words = get_weighted_words(words, first_letters, last_letters)

    if not weighted_words:
        break

    weighted_words.sort(key=lambda x: x[1])

    excluded_word = weighted_words[0][0]
    words.remove(excluded_word)
    first_letters[excluded_word[0]] -= 1
    last_letters[excluded_word[1]] -= 1
    wish_fulfills += 1


print(wish_fulfills)
