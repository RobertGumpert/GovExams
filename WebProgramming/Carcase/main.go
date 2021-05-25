package main

import (
	"github.com/gin-contrib/cors"
	"github.com/gin-gonic/gin"
	"log"
	"path/filepath"
	"runtime"
	"webproject/config/staticConfigs"
	"webproject/src/controller"
	"webproject/src/dao"
	"webproject/src/orm"
	"webproject/src/service"
)

func main() {
	engine := getServer()
	//
	configs := staticConfigs.Read()
	ormFacade := getOrm(configs)
	daoFacade := dao.NewDAO(ormFacade.GetOrm(orm.Postgres))
	serviceFacade := service.NewService(daoFacade, configs)
	_ = controller.NewController(engine, serviceFacade)
	//
	err := engine.Run(configs.App.Port)
	if err != nil {
		log.Fatal(err)
	}
}

func getOrm(configs *staticConfigs.Configs) orm.IOrm {
	ormFacade := orm.NewOrmFacade(
		orm.NewPostgreSQL(
			nil,
			configs.Postgres.Username,
			configs.Postgres.Password,
			configs.Postgres.DbName,
			configs.Postgres.Port,
			configs.Postgres.Ssl,
		),
	)
	err := ormFacade.OpenConnection(orm.Postgres)
	if err != nil {
		log.Fatal(err)
	}
	err = ormFacade.Migration(orm.Postgres)
	if err != nil {
		log.Fatal(err)
	}
	return ormFacade
}

func getServer() *gin.Engine {
	_, file, _, _ := runtime.Caller(0)
	root := filepath.Dir(file)
	engine := gin.Default()
	engine.Use(
		cors.Default(),
	)
	engine.Static("/js", root+"/data/assets/js")
	engine.Static("/css", root+"/data/assets/css")
	engine.Static("/images", root+"/data/assets/images")
	engine.LoadHTMLGlob(root + "/data/assets/*.html")
	return engine
}
