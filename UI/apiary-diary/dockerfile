  ### STAGE 1: Build ###
FROM node:14.15.4 AS build
WORKDIR /appUI
COPY src ./src
COPY *.json ./
RUN npm install -g @angular/cli@7.3.10
RUN npm install
RUN ng build --prod

FROM nginx:alpine as deploy
WORKDIR /appUI
COPY --from=build /appUI/dist/apiary-diary/*.* /usr/share/nginx/html/