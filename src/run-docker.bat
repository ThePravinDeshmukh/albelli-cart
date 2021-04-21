#!/bin/bash

docker build -t albellicart .
docker run -it --rm -p 5000:5000 --name albellicartcontainer albellicart
pause..