package controller

import (
	"github.com/gin-gonic/gin"
	"log"
	"net/http"
	"strconv"
	"webproject/src/model/jsonModel"
	"webproject/src/service"
)

type userController struct {
	engine      *gin.Engine
	userService *service.UserService
}

func newUserController(engine *gin.Engine, userService *service.UserService) *userController {
	c := &userController{
		engine:      engine,
		userService: userService,
	}
	user := engine.Group("/user")
	{
		user.POST("/create", c.createUser)
		user.GET("/get/list", c.getList)
		user.GET("/get/list/next/:page", c.middleware, c.pagination)
	}
	return c
}

func (c *userController) middleware(ctx *gin.Context) {
	cookie, err := ctx.Cookie("session")
	if err != nil {
		log.Println("Cookie finish: ", err)
		ctx.AbortWithStatus(http.StatusNotFound)
		return
	}
	log.Println("Cookie: ", cookie)
	return
}

func (c *userController) createUser(ctx *gin.Context) {
	data := new(jsonModel.User)
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

func (c *userController) getList(ctx *gin.Context) {
	response := c.userService.DownloadList(0)
	ctx.SetCookie(
		"session",
		"session",
		5,
		"/",
		"127.0.0.1:54000",
		false,
		true,
	)
	ctx.HTML(http.StatusOK, "user-pagination-page.html", response)
	return
}

func (c *userController) pagination(ctx *gin.Context) {
	page := ctx.Param("page")
	lastSkip, err := strconv.Atoi(page)
	if err != nil {
		ctx.AbortWithStatus(http.StatusNotFound)
		return
	}
	response := c.userService.DownloadList(lastSkip)
	ctx.AbortWithStatusJSON(http.StatusOK, response)
	return
}
