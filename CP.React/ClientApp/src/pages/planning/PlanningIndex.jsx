import { Skeleton, Typography } from "@mui/material";
import Grid from "@mui/material/Grid";
import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import ExportExcel from "./ExportExcel";
import { getMonthName } from "./planning-utils";
import PlanningForm from "./PlanningForm";
import PlanningTable from "./PlanningTable";

function PlanningTableSkeleton() {
  return (
    <Grid container spacing={2}>
      <Grid item xs={2}>
        <Skeleton
          animation="wave"
          variant="rectangular"
          height={35}
          width={190}
        />
      </Grid>
      <Grid item xs={10}></Grid>
      {[...Array(132)].map((e, i) => (
        <Grid key={i} item xs={1}>
          <Skeleton variant="rectangular" animation="wave" />
        </Grid>
      ))}
    </Grid>
  );
}

export default function PlanningIndex() {
  const [showTable, setShowTable] = React.useState(false);
  const [planning, setPlanning] = React.useState(null);

  const handleGeneratePlanning = (values) => {
    setShowTable(true);
    fetch("/api/planning", {
      method: "POST",
      body: JSON.stringify(values),
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then(() => {
        fetch(
          `/api/planning?teamId=${values.teamId}&year=${values.year}&month=${values.month}`,
          { method: "GET" }
        )
          .then((response) => response.json())
          .then((data) => {
            const planning = data.result;
            setPlanning(planning);
          })
          .catch((error) => {
            console.log(error);
          });
      })
      .catch((error) => {
        console.log(error);
      });
  };

  var subContent = planning ? (
    <>
      <Typography variant="h4" borderBottom={1} borderColor="#DEE2E6">
        Team: {planning.team.name} - {getMonthName(planning.month)}{" "}
        {planning.year}
      </Typography>
      <ExportExcel planning={planning} />
      <PlanningTable planning={planning} />
    </>
  ) : (
    <PlanningTableSkeleton />
  );

  var content = showTable ? (
    <>{subContent}</>
  ) : (
    <PlanningForm onGeneratePlanning={handleGeneratePlanning} />
  );

  return (
    <React.Fragment>
      <Header />
      <Main>{content}</Main>
    </React.Fragment>
  );
}
