import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import * as React from "react";
import Controls from "../../components/controls/Controls";
import { useForm } from "../../hooks/useForm";
import { getMonthsForSelectInput } from "./planning-utils";

const initialValues = { month: "0" };

function MonthForm() {
  const [options, setOptions] = React.useState([]);

  React.useEffect(() => {
    const months = getMonthsForSelectInput();
    setOptions(months);
  }, []);

  const form = useForm(initialValues);

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Kies Maand
      </Typography>
      <form>
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <Controls.Select
              fullWidth
              label="Maand"
              name="month"
              onChange={form.handleInputChange}
              options={options}
              required
              value={form.values.month}
              variant="standard"
            />
          </Grid>
        </Grid>
      </form>
    </React.Fragment>
  );
}

export default MonthForm;
