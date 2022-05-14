import { Box, CircularProgress } from "@mui/material";
import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import ExportExcel from "./ExportExcel";
import PlanningTable from "./PlanningTable";
import PlanningWizard from "./PlanningWizard";

const useStyles = () => ({
  progressWrap: { display: "flex", justifyContent: "center" },
});

export default function PlanningIndex() {
  const [isMounted, setIsMounted] = React.useState(false);
  const [showTable, setShowTable] = React.useState(false);
  const [planning, setPlanning] = React.useState(null);

  React.useEffect(() => {
    setIsMounted(true);
  }, []);

  const classes = useStyles();

  const handleGeneratePlanning = (values) => {
    setShowTable(true);
    fetch("https://localhost:44428/api/planning", {
      method: "POST",
      body: JSON.stringify(values),
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then(() => {
        fetch(
          `https://localhost:44428/api/planning?teamId=${values.teamId}&year=${values.year}&month=${values.month}`,
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
      <ExportExcel planning={planning} />
      <PlanningTable planning={planning} />
    </>
  ) : (
    <Box sx={classes.progressWrap}>
      <CircularProgress />
    </Box>
  );

  var content = showTable ? (
    <>{subContent}</>
  ) : (
    <PlanningWizard onGeneratePlanning={handleGeneratePlanning} />
  );

  return (
    <React.Fragment>
      <Header />
      <Main>{content}</Main>
    </React.Fragment>
  );
}
