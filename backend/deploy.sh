#!bin//bash

echo "Checking if docker is installed"
if ! [ -x "$(command -v docker)" ]; then
    echo "Install and start docker"
    yum update -y
    yum install -y docker
    service docker start
    usermod -a -G docker ec2-user
    echo "Done..."
    echo "Installing Docker compose"
    sudo curl -L "https://github.com/docker/compose/releases/download/1.24.1/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
    sudo chmod +x /usr/local/bin/docker-compose
    echo "Done..."
else
    echo 'Docker is installed'
fi

docker pull jenkinsci/blueocean

docker run \
  -u root \
  --rm \
  -d \
  -p 8080:8080 \
  -v ~/jenkins-data:/var/jenkins_home \
  -v /var/run/docker.sock:/var/run/docker.sock \
  --name jenkins \
  jenkinsci/blueocean
