FROM ubuntu:latest

WORKDIR /app
COPY ../ ./

RUN apt-get update && apt-get install -y python3 python3-pip gcc git
RUN pip install -r requirements.txt