import sys

filename = sys.argv[1]
fh = open(filename, 'r')
count = 0
eof = False
file = ""
while count <= 18:
    line = fh.readline().strip('\n')
    count += 1


while eof == False:
    line = fh.readline().strip('\n')
    if line == '-- End of file':
        eof = True
    elif 'DROP' in line:
        pass
    else:
        print(line)
        file += line + "\n"
        count += 1

fileWriter = open('prod_sqlscript.sql', 'w')
fileWriter.write(file)
