FROM nginx:alpine

COPY app-softplan/nginx.conf /etc/nginx/nginx.conf

WORKDIR /usr/share/nginx/html
COPY app-softplan/dist/app-softplan/ .