#!/bin/bash

cd ..\src

docker run --publish 8761:8761 steeltoeoss/eureka-server

docker build -t albellicart .

docker run -it --rm -p 5000:5000 --name albellicartcontainer albellicart

pause..