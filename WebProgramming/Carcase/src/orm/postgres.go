package orm

import (
	"fmt"
	"gorm.io/driver/postgres"
	"gorm.io/gorm"
	"log"
	"webproject/src/model/dataModel"
)

type PostgreSQL struct {
	db     *gorm.DB
	params []string
	config *gorm.Config
}


func NewPostgreSQL(config *gorm.Config, params ...string) IOrm {
	return &PostgreSQL{
		params: params,
		config: config,
	}
}

func (p *PostgreSQL) OpenConnection(DBType) error {
	interfaces := make([]interface{}, len(p.params))
	for i, v := range p.params {
		interfaces[i] = v
	}
	dsn := fmt.Sprintf(string(dsnPostgresPostgres), interfaces...)
	if p.config == nil {
		p.config = &gorm.Config{}
	}
	connect, err := gorm.Open(postgres.Open(dsn), p.config)
	if err != nil {
		log.Fatal(err)
	}
	p.db = connect
	return nil
}

func (p *PostgreSQL) Migration(dbType DBType) error {
	db := p.db.Begin()
	defer func() {
		if r := recover(); r != nil {
			db.Rollback()
		}
	}()

	if err := db.AutoMigrate(
		&dataModel.User{},
		&dataModel.Article{},
	); err != nil {
		db.Rollback()
		return err
	}
	return db.Commit().Error
}

func (p *PostgreSQL) CloseConnection(DBType) error {
	db, err := p.db.DB()
	if err != nil {
		return err
	}
	err = db.Close()
	if err != nil {
		return err
	}
	return nil
}

func (p *PostgreSQL) GetDB(db DBType) *gorm.DB {
	return p.db
}

func (p *PostgreSQL) GetOrm(dbType DBType) IOrm {
	return p
}

func (p *PostgreSQL) GetType() DBType {
	return Postgres
}
