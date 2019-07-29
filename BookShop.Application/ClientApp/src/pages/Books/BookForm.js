import React, { Component } from "react";
import Api from "../../services/api";
import {
  Col,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  UncontrolledAlert
} from "reactstrap";

export default class BookForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      alredyLoaded: false,
      error: null,
      form: {
        title: "",
        description: "",
        pages: "",
        stock: "",
        isbn10: "",
        isbn13: "",
        editionyear: ""
      }
    };

    if (
      this.props.match &&
      this.props.match.params &&
      this.props.match.params.id
    ) {
      Api.get(`/book/${this.props.match.params.id}`)
        .then(response => {
          this.setState({ form: response.data, alreadyLoaded: true });
        })
        .catch(response => {
          this.setState({ alreadyLoaded: false });
          alert("Ops, something went wrong. Please, try again");
          console.error(response);
        });
    }
  }

  isNumeric = n => !isNaN(parseFloat(n)) && isFinite(n);

  isFormValid = () => {
    let errors = null;

    const notEmpty = ["title", "pages", "stock"];
    notEmpty.forEach(val => {
      if (!this.state.form[val]) {
        errors = errors || {};
        errors[val] = errors[val] || [];
        errors[val].push("This field is required");
      }
    });
    if (!this.state.form.title) {
      errors = errors || {};
      errors.title = [];
      errors.title.push("This field is required");
    }

    const numerics = ["pages", "isbn10", "isbn13", "stock", "editionyear"];
    numerics.forEach(val => {
      if (this.state.form[val] && !this.isNumeric(this.state.form[val])) {
        errors = errors || {};
        errors[val] = errors[val] || [];
        errors[val].push("This field must be a valid number");
      }
    });

    if (errors) {
      this.setState({ error: errors });
      return false;
    }

    return true;
  };

  submitForm = async () => {
    if (!this.isFormValid()) {
      return;
    }

    try {
      if (
        this.props.match &&
        this.props.match.params &&
        this.props.match.params.id
      ) {
        await Api.put(`/book/${this.props.match.params.id}`, this.state.form);
        alert("Success on editing book!");
        this.props.history.push("/");
      } else {
        await Api.post("/book", this.state.form);
        alert("Success on saving book!");
        this.cleanForm();
      }
    } catch (error) {
      if (error.response && error.response.data && error.response.data.errors) {
        this.setState({ error: error.response.data.errors });
      }
      console.error(error);
    }
  };

  resetPage = () => {
    this.cleanForm();
    this.props.history.push("/book/form");
  };

  cleanForm = () => {
    this.setState({
      error: null,
      form: {
        title: "",
        description: "",
        pages: "",
        stock: "",
        isbn10: "",
        isbn13: "",
        editionyear: ""
      }
    });
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.value;
    const name = target.name;

    const form = { ...this.state.form };
    form[name] = value;

    this.setState({ form });
  };

  renderErrorMessage = () => {
    const final = [];
    Object.entries(this.state.error).forEach(([key, value]) => {
      final.push(<p className="text-capitalize">{key}: </p>);

      final.push(
        <ul>
          {value.map(message => (
            <li>{message}</li>
          ))}
        </ul>
      );
    });

    return <UncontrolledAlert color="danger">{final}</UncontrolledAlert>;
  };

  render() {
    if (
      this.props.match &&
      this.props.match.params &&
      this.props.match.params.id &&
      !this.state.alreadyLoaded
    ) {
      return (
        <p>
          <em>Loading...</em>
        </p>
      );
    }

    return (
      <div>
        {this.state.error && this.renderErrorMessage()}
        <Form>
          <FormGroup row>
            <Label sm={2} for="title">
              Title
            </Label>
            <Col sm={10}>
              <Input
                type="text"
                name="title"
                id="title"
                value={this.state.form.title}
                onChange={this.handleInputChange}
                required
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label sm={2} for="description">
              Description
            </Label>
            <Col sm={10}>
              <Input
                type="textarea"
                name="description"
                id="description"
                value={this.state.form.description}
                onChange={this.handleInputChange}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label sm={2} for="pages">
              Pages
            </Label>
            <Col sm={10}>
              <Input
                type="numeric"
                name="pages"
                id="pages"
                value={this.state.form.pages}
                onChange={this.handleInputChange}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label sm={2} for="stock">
              Stock
            </Label>
            <Col sm={10}>
              <Input
                type="numeric"
                name="stock"
                id="stock"
                value={this.state.form.stock}
                onChange={this.handleInputChange}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label sm={2} for="isbn10">
              Isbn10
            </Label>
            <Col sm={10}>
              <Input
                type="text"
                name="isbn10"
                id="isbn10"
                value={this.state.form.isbn10}
                onChange={this.handleInputChange}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label sm={2} for="isbn13">
              Isbn13
            </Label>
            <Col sm={10}>
              <Input
                type="text"
                name="isbn13"
                id="isbn13"
                value={this.state.form.isbn13}
                onChange={this.handleInputChange}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label sm={2} for="editionyear">
              Edition Year
            </Label>
            <Col sm={10}>
              <Input
                type="textarea"
                name="editionyear"
                id="editionyear"
                value={this.state.form.editionyear}
                onChange={this.handleInputChange}
              />
            </Col>
          </FormGroup>

          <Button onClick={this.resetPage}>New</Button>
          <Button onClick={this.submitForm} color="primary" className="ml-1">
            Submit
          </Button>
        </Form>
      </div>
    );
  }
}
