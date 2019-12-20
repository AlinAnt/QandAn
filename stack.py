import requests
import re
import sys

def get_question(url):
    q_id = re.findall(r'questions\/(\d+)', url)[0]
    res = requests.get(f'https://api.stackexchange.com/2.2/questions/{q_id}', {'site': 'stackoverflow', 'filter': 'withbody', 'answers':'True'})
    return res.json()['items'][0]


if __name__ == "__main__":
    url =  sys.argv[1]
    question = get_question(url)

    with open('title.txt', 'w', encoding='utf-8') as g:
        g.write(str(question['title']))
    
    with open('body.txt', 'w', encoding='utf-8') as g:
        g.write(str(question['body']))


