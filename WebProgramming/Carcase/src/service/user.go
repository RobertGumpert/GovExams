package service

import (
	"webproject/src/dao"
)

type UserService struct {
	db *dao.DAO
}

func newUserService(db *dao.DAO) *UserService {
	return &UserService{
		db: db,
	}
}
