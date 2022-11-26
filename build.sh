#!/bin/bash

source version.txt

docker build -t cloud.canister.io:5000/topz/aoc2022:latest -t cloud.canister.io:5000/topz/aoc2022:$MAJOR.$MINOR Aoc2022
