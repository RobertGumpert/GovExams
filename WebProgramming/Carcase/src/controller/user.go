package controller

import (
	"github.com/gin-gonic/gin"
	"log"
	"net/http"
	"webproject/src/controller/jsonModel"
	"webproject/src/service"
)

type userController struct {
	engine      *gin.Engine
	userService *service.UserService
}

func newUserController(engine *gin.Engine, userService *service.UserService) *userController {
	user := engine.Group("/user")
	{
		user.POST("/create", func(context *gin.Context) {

		})
		user.GET("/get", func(context *gin.Context) {

		})
	}
	return &userController{
		engine: engine,
		userService: userService,
	}
}


func (c *userController) createUser(ctx *gin.Context) {
	data := new(jsonModel.CreateUser)
	if err := ctx.BindJSON(data); err != nil {
		log.Println(err)
		ctx.AbortWithStatus(http.StatusNotFound)
		return
	}
	//
	//
	//
	ctx.AbortWithStatusJSON(http.StatusOK, data)
	return
}