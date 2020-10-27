#! python3
#source: https://gitee.com/kingreatwill/penter/blob/master/example/githubhosts.py
#need install module:
#pip install requests
#pip install tldextract
#pip install bs4
#pip install pythonping

need_domains = ['github.com',
                'gist.github.com',
                'assets-cdn.github.com',
                'raw.githubusercontent.com',
                'gist.githubusercontent.com',
                'cloud.githubusercontent.com',
                'camo.githubusercontent.com',
                'avatars0.githubusercontent.com',
                'avatars1.githubusercontent.com',
                'avatars2.githubusercontent.com',
                'avatars3.githubusercontent.com',
                'avatars4.githubusercontent.com',
                'avatars5.githubusercontent.com',
                'avatars6.githubusercontent.com',
                'avatars7.githubusercontent.com',
                'avatars8.githubusercontent.com',
                'api.github.com',  # 以下新增
                'documentcloud.github.com',
                'help.github.com',
                'nodeload.github.com',
                'codeload.github.com',
                'raw.github.com',
                'status.github.com',
                'training.github.com',
                'github.global.ssl.fastly.net',
                ]


# 利用海外的机器进行相关网站的DNS查询, 本地机器不行
# https://github.com/ButterAndButterfly/GithubHost
def haiwai_output_hosts(domains):
    import socket
    with open('hosts.txt', 'w') as f:
        f.write('```\n')
        f.write('# GitHub Start \n')
        for domain in domains:
            print('Querying ip for domain %s' % domain)
            ip = socket.gethostbyname(domain)
            print(ip)
            f.write('%s %s\n' % (ip, domain))
        f.write('# GitHub End \n')
        f.write('```\n')


# 根据ipaddress.com 或者 https://site.ip138.com/ 搜索域名IP，然后在本机ping ip看下哪个最快，确定最终ip
def ip138_output_hosts(domains):
    import requests
    import time
    import json
    headers = {
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36'}
    for domain in domains:
        resp = requests.get(url='https://site.ip138.com/domain/read.do', headers=headers,
                            params={'domain': domain, 'time': int(round(time.time() * 1000))})
        if resp.ok:
            print(resp.url)
            print(resp.json())
    ...
    # 获取token： https://site.ip138.com/avatars1.githubusercontent.com/
    # https://site.ip138.com/domain/write.do?input=avatars1.githubusercontent.com&token=1865a1de58c2228b88b5d5c8c45b9863
    # https://site.ip138.com/domain/read.do?domain=raw.githubusercontent.com&time=1598249072506 #毫秒级时间戳，13位


# ipaddress.com (java 版本：https://gitee.com/bryan31/githubhost/)
def ipaddress_output_hosts(domains):
    import os
    import sys
    import requests
    import json
    import tldextract # install tldextract
    from bs4 import BeautifulSoup  # install beautifulsoup4
    from pythonping import ping # install pythonping
    # https://github.com/alessandromaggio/pythonping 也可以试下 https://github.com/romana/multi-ping

    print("# windows: ipconfig /flushdns \n# linux:sudo killall -HUP mDNSResponder")
    headers = {
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36'}
    # https://githubusercontent.com.ipaddress.com/avatars3.githubusercontent.com
    for domain in domains:
        result = tldextract.extract(domain)
        if result.registered_domain == domain:
            url = "https://{}.ipaddress.com".format(domain)
        else:
            url = "https://{}.ipaddress.com/{}".format(result.registered_domain, domain)

        resp = requests.get(url=url, headers=headers)
        if resp.ok:
            try:
                soup = BeautifulSoup(resp.text, 'html.parser')
                has_ip_table = soup.select('table[class="panel-item table table-stripes table-v"]')[0]
                ips = has_ip_table.select('tr')[-1].select('td ul li')
                curr_ip = None
                curr_ms = sys.maxsize
                if len(ips) == 1:
                    curr_ip = ips[0].text
                else:
                    for ip in ips:
                        if not curr_ip:
                            curr_ip = ip.text
                        # result = os.popen('ping -c 1 {}'.format(ip.text)).read()
                        # result = os.popen('ping -n 10 {}'.format(ip.text)).read() # win
                        p_r = ping(ip.text, timeout=5, count=10, verbose=False)
                        if p_r.rtt_avg_ms < curr_ms:
                            curr_ip = ip.text
                            curr_ms = p_r.rtt_avg_ms
                if not curr_ip:
                    print("# {} 没有找到IP。".format(curr_ip, domain))
                else:
                    print("{} {}".format(curr_ip, domain))
            except Exception:
                print("# domain:{}, 没有找到IP.".format(domain))


if __name__ == '__main__':
    # haiwai_output_hosts(need_domains)
    ipaddress_output_hosts(need_domains)
    input("please input any key...")
