# connect to redis from docker


- create a network
``` sh
docker network create -d bridge <network name>
```

- create a docker container
``` sh
docker run -d -p 6379:6379 --name <container name> --network <network name> redis
```

- run this in containers terminal to connect to redis cli 
``` sh
redis-cli -h 127.0.0.1 -p 6379
```

- now set and get values from redis
```
set <key> <value>
get <key>
```