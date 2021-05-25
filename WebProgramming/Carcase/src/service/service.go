package service

import (
	"webproject/config/staticConfigs"
	"webproject/src/dao"
)

type Service struct {
	config *staticConfigs.Configs
	//
	User *UserService
}

func NewService(db *dao.DAO, config *staticConfigs.Configs) *Service {
	return &Service{
		config: config,
		User:   newUserService(db),
	}
}
