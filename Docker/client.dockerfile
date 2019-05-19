FROM node:alpine as builder
RUN npm i -g @angular/cli
WORKDIR /src
COPY Client .
RUN npm install
RUN ng build --prod --aot=false --build-optimizer=false --outputPath /dist

FROM nginx:alpine as runner
WORKDIR /usr/share/nginx/html
COPY --from=builder /dist .
EXPOSE 80