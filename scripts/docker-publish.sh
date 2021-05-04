DOCKER_ENV=''
DOCKER_TAG=''
case $TRAVIS_BRANCH in
  master)
    DOCKER_ENV=production
    DOCKER_TAG=latest
    ;;
  develop)
    DOCKER_ENV=development
    DOCKER_TAG=dev
    ;;    
esac

