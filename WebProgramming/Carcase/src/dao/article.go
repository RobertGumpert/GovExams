package dao

import "webproject/src/orm"

type articleDao struct {
	db orm.IOrm
}

func newArticleDao(db orm.IOrm) *articleDao {
	return &articleDao{db: db}
}