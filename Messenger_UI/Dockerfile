#stage 1
FROM node:latest as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod
#stage 2
FROM nginx:alpine
COPY --from=node /dist/messenger-ui /usr/share/nginx/html

# command for building docker container
#docker build -t pavankumar21106/angular-app .
