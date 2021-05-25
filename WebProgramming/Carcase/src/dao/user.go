package dao

import (
	"webproject/src/model/dataModel"
	"webproject/src/orm"
)

type userDao struct {
	db             orm.IOrm
	paginationSize int
}

func newUserDao(db orm.IOrm, paginationSize int) *userDao {
	return &userDao{
		db:             db,
		paginationSize: paginationSize,
	}
}

func (u *userDao) Create(user *dataModel.User) error {
	tx := u.db.GetDB(0).Begin()
	defer func() {
		if r := recover(); r != nil {
			tx.Rollback()
		}
	}()
	if err := tx.Create(user).Error; err != nil {
		tx.Rollback()
		return err
	}
	return tx.Commit().Error
}

func (u *userDao) GetByID(id uint) (dataModel.User, error) {
	var user dataModel.User
	if err := u.db.GetDB(0).Where("id = ?", id).First(&user).Error; err != nil {
		return user, err
	}
	return user, nil
}

func (u *userDao) GetByName(name string) (dataModel.User, error) {
	var user dataModel.User
	if err := u.db.GetDB(0).Where("name = ?", name).First(&user).Error; err != nil {
		return user, err
	}
	return user, nil
}

func (u *userDao) Update(id uint, user *userDao) error {
	tx := u.db.GetDB(0).Begin()
	defer func() {
		if r := recover(); r != nil {
			tx.Rollback()
		}
	}()
	if err := tx.Updates(user).Error; err != nil {
		tx.Rollback()
		return err
	}
	return tx.Commit().Error
}

func (u *userDao) Delete(id uint) error {
	tx := u.db.GetDB(0).Begin()
	defer func() {
		if r := recover(); r != nil {
			tx.Rollback()
		}
	}()
	if err := tx.Delete(&dataModel.User{}, id).Error; err != nil {
		tx.Rollback()
		return err
	}
	return tx.Commit().Error
}

func (u *userDao) Pagination(lastSkip int) ([]dataModel.User, int, error) {
	var (
		users []dataModel.User

		nextSkip = lastSkip + u.paginationSize
	)
	if err := u.db.GetDB(0).Offset(lastSkip).Limit(u.paginationSize).Find(&users).Error; err != nil {
		return nil, nextSkip, err
	}
	return users, nextSkip, nil
}
