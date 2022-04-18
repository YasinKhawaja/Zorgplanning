import { Grid } from "@mui/material";
import parse from "html-react-parser";
import React from "react";
import Controls from "../../components/controls/Controls";
import { Form, useForm } from "../../hooks/useForm";

const useStyles = () => ({
  buttonsWrap: {
    display: "flex",
    justifyContent: "space-between",
  },
});

const initialValues = {
  id: 0,
  name: "",
  hasChildren: false,
};

function TeamForm(props) {
  React.useEffect(() => {
    if (props.teamToEdit != null) {
      setValues({ ...props.teamToEdit });
    }
    if (props.apiErrors != null) {
      setErrors({ ...props.apiErrors });
    }
  }, [props.teamToEdit, props.apiErrors]);

  const { values, setValues, errors, setErrors, handleInputChange, resetForm } =
    useForm(initialValues, false);

  const classes = useStyles();

  const handleSubmit = (event) => {
    event.preventDefault();
    props.onAddOrEdit(values, resetForm);
  };

  const getErrors = (input) => {
    if (errors === null) return "";
    if (errors[input] === undefined) return "";
    let errorMsg = "";
    errors[input].map((error) => {
      errorMsg += `${error.toString()}<br />`;
    });
    return parse(errorMsg); // Parse to JSX
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Grid container>
        <Grid sx={{ marginBottom: "16px" }} item xs={12}>
          {/* NAME */}
          <Controls.Input
            error={getErrors("Name")}
            label="Name"
            name="name"
            value={values.name}
            onChange={handleInputChange}
          />
        </Grid>
      </Grid>
      <div style={classes.buttonsWrap}>
        <Controls.Button color="grey" text="RESET" onClick={resetForm} />
        <Controls.Button text="SUBMIT" type="submit" />
      </div>
    </Form>
  );
}

export default TeamForm;
