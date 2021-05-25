package dao

import (
	"webproject/config/staticConfigs"
	"webproject/src/orm"
)

type DAO struct {
	User    *userDao
	Article *articleDao
}

func NewDAO(db orm.IOrm, configs *staticConfigs.Configs) *DAO {
	return &DAO{
		User:    newUserDao(db, configs.App.PaginationSize),
		Article: newArticleDao(db),
	}
}

