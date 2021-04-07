# Ocelot Demo

此项目为 Ocelot + Consul + SkyWalking + ASP.NET Core API 的演示程序  
项目内提供了 SkyWalking 和测试用的 Docker-Compose 文件

## 启动流程

---

启动 SkyWalking (可选)

```
cd OcelotGatewaysDemo\DockerSuppot\SkyWalking\
docker-compose up -d --force-recreate
```

启动项目

```
cd OcelotGatewaysDemo
docker-compose up -d --force-recreate
```

访问本机 http://localhost:9070/testagg  
正常应该会显示两个聚合的 API 接口信息

## 项目网络

### SkyWalking

---

| 服务              | 端口  |
| ----------------- | ----- |
| ES                | 9200  |
| SkyWalking OAP    | 11800 |
| SkyWalking WebGUI | 8900  |

### Ocelot Demo

---

使用 Docker 的网络，名称为： dev-net

| 服务             | 端口 |
| ---------------- | ---- |
| consul           | 8500 |
| gateways(ocelot) | 9070 |
| testapia         | 9060 |
| testapia_1       | 9061 |
| testapib         | 9050 |
| testapib_1       | 9051 |
