package dao

import (
	"log"
	"strconv"
	"testing"
	"webproject/config/staticConfigs"
	"webproject/src/model/dataModel"
	"webproject/src/orm"
)

var (
	configs = &staticConfigs.Configs{
		App: &staticConfigs.AppConfigs{
			Port:           "",
			PaginationSize: 20,
		},
		Postgres: &staticConfigs.PostgresConfigs{
			Username: "postgres",
			Password: "toster123",
			Port:     "5432",
			DbName:   "gos",
			Ssl:      "disable",
		},
	}
)

func getOrm() orm.IOrm {
	ormFacade := orm.NewOrmFacade(
		orm.NewPostgreSQL(
			nil,
			configs.Postgres.Username,
			configs.Postgres.Password,
			configs.Postgres.DbName,
			configs.Postgres.Port,
			configs.Postgres.Ssl,
		),
	)
	err := ormFacade.OpenConnection(orm.Postgres)
	if err != nil {
		log.Fatal(err)
	}
	return ormFacade.GetOrm(orm.Postgres)
}

func TestCreateUserFlow(t *testing.T) {
	ud := newUserDao(getOrm(), configs.App.PaginationSize)
	for i := 0; i < 100; i++ {
		name := "name_" + strconv.Itoa(i)
		err := ud.Create(
			&dataModel.User{
				Name:     name,
				Password: name,
			},
		)
		if err != nil {
			t.Fatal(err)
		}
	}
}

func TestPaginationFlow(t *testing.T) {
	var (
		ud       = newUserDao(getOrm(), configs.App.PaginationSize)
		lastSkip = 0
		nextSkip = 0
		err      error
		users    []dataModel.User
	)
	for {
		log.Println("LAST SKIP: ", lastSkip)
		users, nextSkip, err = ud.Pagination(lastSkip)
		if err != nil {
			log.Println("--> ERROR: ", err)
		}
		if len(users) == 0 {
			break
		} else {
			for _, u := range users {
				log.Println("--> USER: id[", u.ID, "], name[", u.Name, "], password[", u.Password, "]")
			}
		}
		lastSkip = nextSkip
		log.Println("NEXT")
	}

}
