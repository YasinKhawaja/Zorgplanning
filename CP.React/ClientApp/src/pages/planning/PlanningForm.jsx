import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Container from "@mui/material/Container";
import Paper from "@mui/material/Paper";
import Typography from "@mui/material/Typography";
import * as React from "react";
import { useForm } from "../../hooks/useForm";
import TeamService from "../../services/TeamService";
import MonthForm from "./MonthForm";
import {
  areAllKeysPopulated,
  getMonthsForSelectInput,
  getYearsForSelectInput,
  mapTeamsForSelectInput,
} from "./planning-utils";
import TeamForm from "./TeamForm";
import YearForm from "./YearForm";

const initialValues = {
  teamId: "",
  year: new Date().getFullYear(),
  month: (new Date().getMonth() + 2) % 12,
};

export default function PlanningForm(props) {
  const [teamOptions, setTeamOptions] = React.useState([]);
  const [yearOptions, setYearOptions] = React.useState([]);
  const [monthOptions, setMonthOptions] = React.useState([]);

  console.log(initialValues);

  React.useEffect(() => {
    // Teams
    fetchTeams();
    // Years
    const years = getYearsForSelectInput(new Date().getFullYear());
    setYearOptions(years);
    // Months
    const months = getMonthsForSelectInput();
    setMonthOptions(months);
  }, []);

  const form = useForm(initialValues);

  const fetchTeams = () => {
    TeamService.getAll()
      .then((response) => {
        const teams = response.data.result;
        const filteredResult = mapTeamsForSelectInput(teams);
        setTeamOptions(filteredResult);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    if (areAllKeysPopulated(form.values)) {
      props.onGeneratePlanning(form.values);
    }
  };

  return (
    <Container component="div" maxWidth="sm">
      <Paper variant="outlined" sx={{ p: { xs: 2, md: 3 } }}>
        <Typography component="h1" variant="h4" align="center">
          Planning
        </Typography>
        <form onSubmit={handleSubmit}>
          <Box>
            <TeamForm options={teamOptions} form={form} />
          </Box>
          <Box sx={{ mt: 3 }}>
            <YearForm options={yearOptions} form={form} />
          </Box>
          <Box sx={{ mt: 3 }}>
            <MonthForm options={monthOptions} form={form} />
          </Box>
          <Box sx={{ display: "flex", justifyContent: "flex-end" }}>
            <Button
              sx={{ mt: 3, ml: 1 }}
              type="submit"
              variant="contained"
              disableElevation
              {...(teamOptions.length === 0 || !areAllKeysPopulated(form.values)
                ? { disabled: true }
                : null)}
            >
              Genereer
            </Button>
          </Box>
        </form>
      </Paper>
    </Container>
  );
}
