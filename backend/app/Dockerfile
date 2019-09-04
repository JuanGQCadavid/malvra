FROM python:3.6

MAINTAINER Krusty Krab Inc.

COPY . /app

WORKDIR /app

RUN pip install -r requirements.txt

EXPOSE 5000

CMD ["python", "app.py"]