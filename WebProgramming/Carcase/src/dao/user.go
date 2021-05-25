package dao

import (
	"webproject/src/model"
	"webproject/src/orm"
)

type userDao struct {
	db orm.IOrm
}

func newUserDao(db orm.IOrm) *userDao {
	return &userDao{db: db}
}

func (u *userDao) Create(user *userDao) error {
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

func (u *userDao) GetByID(id uint) (model.UserDataModel, error) {
	var user model.UserDataModel
	if err := u.db.GetDB(0).Where("id = ?", id).First(&user).Error; err != nil {
		return user, err
	}
	return user, nil
}

func (u *userDao) GetByName(name string) (model.UserDataModel, error) {
	var user model.UserDataModel
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
	if err := tx.Delete(&model.UserDataModel{}, id).Error; err != nil {
		tx.Rollback()
		return err
	}
	return tx.Commit().Error
}

