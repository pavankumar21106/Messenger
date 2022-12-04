#stage 1
FROM node:latest as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod
#stage 2
FROM nginx:alpine
COPY --from=node /app/dist/messenger-ui /usr/share/nginx/html

# command for building docker container
#docker build -t pavankumar21106/angular-app .
#  docker ps -a
#  docker image -ls
#  docker image ls
#  docker
#  docker run --name angular-app 72cb671ed673 -v --help
#  docker run --name angular-app 72cb671ed673  --help
#  docker run  --help
#  docker run 72cb671ed673 --name angualr-app -p 4201:80
#  docker run --name angualr-app -p 4201:80 72cb671ed673
#  docker run -it --name angualr-app1 -p 8000:80 72cb671ed673
# : docker create -it --name angualr-app1 -p 8000:80 72cb671ed673
# : docker create -it --name angualr-app2 -p 8000:80 72cb671ed673
# : docker start angualr-app2
# : docker exec -it angualr-app2 /bin/bash
# : docker exec -it angualr-app2 sh
# : docker create -it --name nginx nginx:latest -v D:\PostgreSQL_Docker:/var/www/html
#alpine3.17
#docker run 15.1-alpine3.17



