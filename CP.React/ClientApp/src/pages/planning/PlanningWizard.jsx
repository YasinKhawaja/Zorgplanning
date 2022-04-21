import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Container from "@mui/material/Container";
import Paper from "@mui/material/Paper";
import Step from "@mui/material/Step";
import StepLabel from "@mui/material/StepLabel";
import Stepper from "@mui/material/Stepper";
import Typography from "@mui/material/Typography";
import * as React from "react";
import { useForm } from "../../hooks/useForm";
import TeamService from "../../services/TeamService";
import MonthForm from "./MonthForm";
import {
  getMonthsForSelectInput,
  getYearsForSelectInput,
  mapTeamsForSelectInput,
} from "./planning-utils";
import TeamForm from "./TeamForm";
import YearForm from "./YearForm";

const initialValues = { teamId: "", year: "", month: "" };

const steps = ["Team", "Jaar", "Maand"];

function PlanningWizard(props) {
  const { onChangePlanningValues } = props;

  const [activeStep, setActiveStep] = React.useState(0);
  const [teamOptions, setTeamOptions] = React.useState([]);
  const [yearOptions, setYearOptions] = React.useState([]);
  const [monthOptions, setMonthOptions] = React.useState([]);

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

  const getStepContent = (step) => {
    switch (step) {
      case 0:
        return <TeamForm options={teamOptions} form={form} />;
      case 1:
        return <YearForm options={yearOptions} form={form} />;
      case 2:
        return <MonthForm options={monthOptions} form={form} />;
      default:
        throw new Error("Unknown step");
    }
  };

  const getOptionById = (options, id) => {
    return options.find((option) => option.id === id);
  };

  const handleNext = () => {
    setActiveStep(activeStep + 1);
  };

  const handleBack = () => {
    setActiveStep(activeStep - 1);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    const changedPlanningValues = { ...form.values };
    onChangePlanningValues(changedPlanningValues);
    handleNext();
  };

  return (
    <Container component="div" maxWidth="sm">
      <Paper variant="outlined" sx={{ p: { xs: 2, md: 3 } }}>
        <Typography component="h1" variant="h4" align="center">
          Planning Wizard
        </Typography>
        <Stepper activeStep={activeStep} sx={{ pt: 3, pb: 5 }}>
          {steps.map((label) => (
            <Step key={label}>
              <StepLabel>{label}</StepLabel>
            </Step>
          ))}
        </Stepper>
        <React.Fragment>
          {activeStep === steps.length ? (
            <React.Fragment>
              <Typography variant="h5" gutterBottom>
                Thank you for your inputs.
              </Typography>
              <Typography variant="subtitle1">
                A monthly planning for{" "}
                <b>{getOptionById(teamOptions, form.values.teamId).name}</b> for{" "}
                <b>{getOptionById(monthOptions, form.values.month).name}</b>{" "}
                <b>{getOptionById(yearOptions, form.values.year).name}</b> will
                be generated shortly.
              </Typography>
            </React.Fragment>
          ) : (
            <React.Fragment>
              <form onSubmit={handleSubmit}>
                {getStepContent(activeStep)}
                <Box sx={{ display: "flex", justifyContent: "flex-end" }}>
                  {activeStep !== 0 && (
                    <Button onClick={handleBack} sx={{ mt: 3, ml: 1 }}>
                      Back
                    </Button>
                  )}
                  <Button
                    sx={{ mt: 3, ml: 1 }}
                    type="submit"
                    variant="contained"
                  >
                    {activeStep === steps.length - 1 ? "Finish" : "Next"}
                  </Button>
                </Box>
              </form>
            </React.Fragment>
          )}
        </React.Fragment>
      </Paper>
    </Container>
  );
}

export default PlanningWizard;
