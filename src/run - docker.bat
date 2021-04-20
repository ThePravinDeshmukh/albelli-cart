#!/bin/bash

docker build -t albellicart .
docker run -it --rm -p 80:5000 --name albellicartcontainer albellicart
