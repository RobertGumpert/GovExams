package dao

import "webproject/src/orm"

type DAO struct {
	User    *userDao
	Article *articleDao
}

func NewDAO(db orm.IOrm) *DAO {
	return &DAO{
		User:    newUserDao(db),
		Article: newArticleDao(db),
	}
}

