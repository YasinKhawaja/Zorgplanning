import { makeStyles } from "@mui/styles";
import React from "react";

function useForm(initialValues, validateOnChange = false, validate) {
  const [values, setValues] = React.useState(initialValues);
  const [errors, setErrors] = React.useState(null);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setValues({ ...values, [name]: value });
    if (validateOnChange) {
      validate({ [name]: value });
    }
  };

  const resetForm = () => {
    setValues(initialValues);
    setErrors(null);
  };

  return {
    values,
    setValues,
    errors,
    setErrors,
    handleInputChange,
    resetForm,
  };
}

const useStyles = makeStyles((theme) => ({
  root: {
    "& .MuiFormControl-root": {
      margin: theme.spacing(0),
      width: "100%",
    },
  },
}));

function Form(props) {
  const { children, ...other } = props;
  const classes = useStyles();
  return (
    <form className={classes.root} {...other}>
      {children}
    </form>
  );
}

export { useForm, Form };
