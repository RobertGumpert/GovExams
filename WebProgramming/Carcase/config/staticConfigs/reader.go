package staticConfigs

import (
	"encoding/json"
	"io/ioutil"
	"log"
	"path/filepath"
)

type Configs struct {
	App *AppConfigs `json:"app"`
	Postgres *PostgresConfigs `json:"postgres"`
}

func Read() *Configs {
	var(
		c = new(Configs)
	)
	absPath, err := filepath.Abs("./data/config/app.json")
	if err != nil {
		log.Fatal(err)
	}
	content, err := ioutil.ReadFile(absPath)
	if err != nil {
		log.Fatal(err)
	}
	err = json.Unmarshal(content, c)
	if err != nil {
		log.Fatal(err)
	}
	return c
}

