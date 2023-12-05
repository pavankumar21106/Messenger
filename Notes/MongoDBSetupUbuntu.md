# MongoDB setup in ubuntu 

``` shell

sudo apt update
sudo apt install software-properties-common gnupg apt-transport-https ca-certificates -y
curl -fsSL https://pgp.mongodb.com/server-7.0.asc |  sudo gpg -o /usr/share/keyrings/mongodb-server-7.0.gpg --dearmor
echo "deb [ arch=amd64,arm64 signed-by=/usr/share/keyrings/mongodb-server-7.0.gpg ] https://repo.mongodb.org/apt/ubuntu jammy/mongodb-org/7.0 multiverse" | sudo tee /etc/apt/sources.list.d/mongodb-org-7.0.list
sudo apt update
sudo apt install mongodb-org -y
mongod --version
sudo apt install net-tools
sudo netstat -tulpn
change bind address to 0.0.0.0 in /etc/mogod.conf
sudo systemctl status mongod
sudo systemctl start mongod
sudo systemctl status mongod
sudo ss -pnltu | grep 27017
sudo systemctl enable mongod
telnet 18.223.239.27 27017
```

