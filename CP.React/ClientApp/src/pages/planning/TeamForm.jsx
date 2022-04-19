import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import * as React from "react";
import Controls from "../../components/controls/Controls";
import TeamService from "../../services/TeamService";
import { mapTeamsForSelectInput } from "./planning-utils";

function TeamForm() {
  const [options, setOptions] = React.useState(null);

  React.useEffect(() => {
    fetchTeams();
  }, []);

  const fetchTeams = () => {
    TeamService.getAll()
      .then((response) => {
        const teams = response.data.result;
        const filteredResult = mapTeamsForSelectInput(teams);
        setOptions(filteredResult);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Choose Team
      </Typography>
      {options && (
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <Controls.Select
              fullWidth
              label="Team"
              name="teamId"
              required
              options={options}
              variant="standard"
            />
          </Grid>
        </Grid>
      )}
    </React.Fragment>
  );
}

export default TeamForm;
