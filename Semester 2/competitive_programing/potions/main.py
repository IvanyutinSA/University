def do_action(operation: str, args: list) -> str:
    result = operation
    for arg in args:
        if arg.isdigit():
            result += actions[int(arg)-1]
        else:
            result += arg
    result += operation[::-1]
    return result


def adapt_name(operation):
    if operation == 'WATER': return 'WT'
    if operation == 'FIRE': return 'FR'
    return operation[0] + operation[-1]


f = open('potion thing/input7.txt')
actions = [x.split('\n')[0].split() for x in f]
for i in range(len(actions)):
    actions[i] = do_action(
        adapt_name(actions[i][0]),
        actions[i][1:]
    )

print(actions[-1])
