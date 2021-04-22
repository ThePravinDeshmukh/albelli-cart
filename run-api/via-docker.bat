#!/bin/bash

# START docker run --publish 8761:8761 steeltoeoss/eureka-server

# START http://localhost:8761/

cd ..\src

docker container stop albellicart
docker container rm albellicart
docker rm albellicart

docker build -t albellicart .

START docker run -it --rm -p 5000:80 --name albellicart albellicart

START http://localhost:5000/ui/playground

pause..