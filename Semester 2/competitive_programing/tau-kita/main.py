def restore_elements_order(sentence: list):
    final_sentence = list()
    while sentence:
        id = -(len(sentence)//2 + len(sentence) % 2)
        final_sentence += [sentence.pop(id)]
        if sentence:
            final_sentence += [sentence.pop(id)]
    return final_sentence


f = open('tau-kita/input_s1_07.txt')
sentence = f.readline().split()
sentence = restore_elements_order(sentence)
for i in range(len(sentence)):
    sentence[i] = ''.join(restore_elements_order(list(sentence[i])))

print(' '.join(sentence))
