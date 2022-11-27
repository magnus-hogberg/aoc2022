#!/bin/bash

set -x

source version.txt

docker build -t cloud.canister.io:5000/topz/aoc2022:latest -t cloud.canister.io:5000/topz/aoc2022:$MAJOR.$MINOR Aoc2022
cat docker-compose.yml.template \
| sed "s/\$MINOR/${MINOR}/g" \
| sed "s/\$MAJOR/${MAJOR}/g" \
> Aoc2022/docker-compose.yml

