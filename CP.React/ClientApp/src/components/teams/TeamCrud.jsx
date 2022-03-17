import React from "react";
import TeamService from "../../services/TeamService";
import TeamCreate from "./TeamCreate";
import TeamList from "./TeamList";

export default function TeamCrud(props) {
  const handleRefresh = () => {
    props.onRefresh();
  };

  const handleCreate = (team) => {
    const data = JSON.stringify(team);
    TeamService.create(data)
      .then(() => {
        handleRefresh();
      })
      .catch((error) => {
        console.error(error);
      });
  };

  const handleUpdate = (id, team) => {
    const data = JSON.stringify(team);
    TeamService.update(id, data)
      .then(() => {
        handleRefresh();
      })
      .catch((error) => {
        console.error(error);
      });
  };

  const handleDelete = (id) => {
    TeamService.remove(id)
      .then(() => {
        handleRefresh();
      })
      .catch((error) => {
        console.error(error);
      });
  };

  return (
    <>
      <TeamList
        teams={props.teams}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
      <TeamCreate onCreate={handleCreate} />
    </>
  );
}
