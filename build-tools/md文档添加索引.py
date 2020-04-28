import os
import sys


def md_add_index(dic, filename):
    """给没有序列的markdown文档自动添加序列号"""
    one_count = 0
    two_count = 0
    three_count = 0
    four_count = 0
    five_count = 0
    six_count = 0

    str = ''
    with open(filename, 'r', encoding='utf8') as fr:
        # 对1-6级标题做处理
        judge_py_code = 1
        for i in fr:
            if i.startswith('```') and judge_py_code == 1:
                judge_py_code -= 1
                str += i
                continue
            if i.startswith('```') and judge_py_code == 0:
                judge_py_code += 1
                str += i
                continue

            if i.startswith('# ') and judge_py_code:
                str += f'# {dic[one_count+1]}、{i.replace("# ","")}\n'
                one_count += 1
                two_count = 0
                continue
            elif i.startswith('## ') and judge_py_code:
                str += f'## {one_count}.{two_count+1} {i.replace("## ","")}\n'
                two_count += 1
                three_count = 0
                continue
            elif i.startswith('### ') and judge_py_code:
                str += f'### {one_count}.{two_count}.{three_count+1} {i.replace("### ","")}\n'
                three_count += 1
                four_count = 0
                continue
            elif i.startswith('#### ') and judge_py_code:
                str += f'#### {one_count}.{two_count}.{three_count}.{four_count+1} {i.replace("#### ","")}\n'
                four_count += 1
                five_count = 0
                continue
            elif i.startswith('##### ') and judge_py_code:
                str += f'##### {one_count}.{two_count}.{three_count}.{four_count}.{five_count+1} {i.replace("##### ","")}\n'
                five_count += 1
                six_count = 0
                continue
            elif i.startswith('###### ') and judge_py_code:
                str += f'###### {one_count}.{two_count}.{three_count}.{four_count}.{five_count}.{six_count+1} {i.replace("###### ","")}\n'
                six_count += 1
                continue

            str += i

    with open(filename, 'w', encoding='utf8') as fw:
        fw.write(str)
        fw.flush()


def get_chinese_num():
    """将1-99转换为汉字"""
    dic = {1: '一', 2: '二', 3: '三', 4: '四', 5: '五', 6: '六', 7: '七', 8: '八', 9: '九', 10: '十'}

    for num in range(10, 100):
        if num > 10 and num < 20:
            str_num = f'十{dic[num-10]}'
            dic[num] = str_num
        elif num % 10 == 0:
            dic[num] = f'{dic[num//10]}十'
        elif num > 20 and num < 100:
            str_num = f'{dic[num//10]}十{dic[num%10]}'
            dic[num] = str_num
    return dic


def run(directo):
    """运行函数，可以传入文件夹，也可以传入文件"""
    dic = get_chinese_num()
    count = 0
    if os.path.isdir(directo):
        for filename in os.listdir(directo):
            if filename.split('.')[-1] == 'md':
                new_filename = os.path.join(directo, filename)
                try:
                    md_add_index(dic, new_filename)
                except UnicodeDecodeError:
                    print(f'{filename} wrong')
                    continue
                count += 1
                print(f'{filename}替换成功, {count}')
    elif os.path.isfile(directo):
        md_add_index(dic, directo)
        print(f'{directo}替换成功')


if __name__ == '__main__':
    try:
        directo = sys.argv[1]
    except IndexError:
        directo = (os.path.abspath(os.path.dirname(__file__)))
    run(directo)
