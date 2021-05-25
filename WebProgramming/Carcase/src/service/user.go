package service

import (
	"log"
	"webproject/src/dao"
	"webproject/src/model/jsonModel"
)

type UserService struct {
	db *dao.DAO
}

func newUserService(db *dao.DAO) *UserService {
	return &UserService{
		db: db,
	}
}

func (s *UserService) DownloadList(lastSkip int) *jsonModel.DownloadUserList {
	var(
		data = &jsonModel.DownloadUserList{
			Users: make([]jsonModel.User, 0),
		}
	)
	list, nextSkip, err := s.db.User.Pagination(lastSkip)
	if err != nil {
		log.Println(err)
		return data
	}
	return data.Adapter(list, nextSkip)
}
