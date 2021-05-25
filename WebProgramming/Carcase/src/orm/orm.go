package orm

import (
	"errors"
	"gorm.io/gorm"
)

type(
	dsnTemplate string
	DBType int
)

const (
	// Username, Password, DBName, Port, SSLMode
	dsnPostgresPostgres dsnTemplate = "user=%s password=%s dbname=%s port=%s sslmode=%s"
	//
	Postgres DBType = 1
)

type IOrm interface {
	OpenConnection(DBType) error
	CloseConnection(DBType) error
	GetDB(db DBType) *gorm.DB
	GetOrm(dbType DBType) IOrm
	GetType() DBType
	Migration(db DBType) error
}

type ORM struct {
	listOrms map[DBType]IOrm
}

func NewOrmFacade(components ...IOrm) IOrm {
	orm := new(ORM)
	orm.listOrms = make(map[DBType]IOrm)
	for _, component := range components {
		orm.listOrms[component.GetType()] = component
	}
	return orm
}

func (orm *ORM) OpenConnection(dbType DBType) error {
	if obj, exist := orm.listOrms[dbType]; exist {
		return obj.OpenConnection(dbType)
	}
	return errors.New("ORM not exist. ")
}


func (orm *ORM) Migration(dbType DBType) error {
	if obj, exist := orm.listOrms[dbType]; exist {
		return obj.Migration(dbType)
	}
	return errors.New("ORM not exist. ")
}


func (orm *ORM) CloseConnection(dbType DBType) error {
	if obj, exist := orm.listOrms[dbType]; exist {
		return obj.CloseConnection(dbType)
	}
	return errors.New("ORM not exist. ")
}

func (orm *ORM) GetDB(dbType DBType) *gorm.DB {
	if obj, exist := orm.listOrms[dbType]; exist {
		return obj.GetDB(dbType)
	}
	return nil
}

func (orm *ORM) GetOrm(dbType DBType) IOrm {
	if obj, exist := orm.listOrms[dbType]; exist {
		return obj
	}
	return nil
}

func (orm *ORM) GetType() DBType {
	return -1
}

