package controller

import (
	"github.com/gin-gonic/gin"
	"net/http"
	"webproject/src/controller/templateModel"
	"webproject/src/service"
)

type Controller struct {
	engine *gin.Engine
	//
	User    *userController
	Service *service.Service
}

func NewController(engine *gin.Engine, service *service.Service) *Controller {
	c := &Controller{
		engine:  engine,
		User:    newUserController(engine, service.User),
		Service: service,
	}
	engine.GET("/", c.index)
	return c
}

func (c *Controller) index(context *gin.Context) {
	context.HTML(http.StatusOK, "index.html", &templateModel.Index{
		Message: "Hello!",
	})
	return
}
