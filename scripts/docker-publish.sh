#!/bin/bash
cd src/Bootstrapper/ApiaryDiary.Bootstrapper
DOCKER_ENV=''
DOCKER_TAG=''
case "$TRAVIS_BRANCH" in
  "master")
    DOCKER_ENV=production
    DOCKER_TAG=latest
    ;;
  "develop")
    DOCKER_ENV=development
    DOCKER_TAG=dev
    ;;    
esac

docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker build -t apiarydiary-api:$DOCKER_TAG -f Dockerfile .
docker tag apiarydiary-api:$DOCKER_TAG $DOCKER_USERNAME/apiarydiary-api:$DOCKER_TAG
docker push $DOCKER_USERNAME/apiarydiary-api:$DOCKER_TAG