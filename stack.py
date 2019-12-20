import requests
import re
import sys

def get_question(url):
    q_id = re.findall(r'questions\/(\d+)', url)[0]
    res = requests.get(f'https://api.stackexchange.com/2.2/questions/{q_id}', {'site': 'stackoverflow', 'filter': 'withbody', 'answers':'True'})
    return res.json()['items'][0]

def data_cleaner(text):
    pattern_1 = re.compile( r'(<[^>]+>)|((www\.[^ ]+)\b)|((https?://)\S+)', re.I)
    lower_case = text.lower()

    return re.sub(pattern_1, '', lower_case)
  

if __name__ == "__main__":
    url =  sys.argv[1]
    question = get_question(url)

    with open('title.txt', 'w', encoding='utf-8') as g:
        g.write(data_cleaner(str(question['title'])))
    
    with open('body.txt', 'w', encoding='utf-8') as g:
        g.write(data_cleaner(str(question['body'])))


