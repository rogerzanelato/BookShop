import React, { Component } from "react";
import Api from "../../services/api";
import ConfirmService from "../../services/confirmService";
import { Button } from "reactstrap";
import { truncateText } from "../../helper/textUtis";
import { withRouter } from "react-router-dom";

class Books extends Component {
  static displayName = Books.name;

  constructor(props) {
    super(props);
    this.state = { books: [], loading: true };

    Api.get("/book").then(response =>
      this.setState({ books: response.data, loading: false })
    );
  }

  renderReducedDescription = description => {
    if (description && description.length > 255) {
      return <span>{truncateText(description, 255)}</span>;
    }

    return description;
  };

  edit = id => {
    this.props.history.push(`/book/form/${id}`);
  };

  remove = async id => {
    const result = await ConfirmService.show(
      "Are you sure?",
      "This action is irreversible!"
    );

    if (result) {
      try {
        await Api.delete(`/book/${id}`);
        const items = this.state.books.filter(item => item.id !== id);
        alert("Book successfully deleted!");
        this.setState({ books: items });
      } catch (e) {
        alert("Ops, something went wrong");
      }
    }
  };

  renderTable = books => {
    return (
      <table className="table table-striped">
        <thead>
          <tr>
            <th width="25%">Title</th>
            <th width="45%">Description</th>
            <th>Stock</th>
            <th>Edition Year</th>
            <th width="15%">Action</th>
          </tr>
        </thead>
        <tbody>
          {books.map(book => (
            <tr key={book.id}>
              <td>{book.title}</td>
              <td>{this.renderReducedDescription(book.description)}</td>
              <td>{book.stock}</td>
              <td>{book.editionYear}</td>
              <td>
                <div>
                  <Button
                    size="sm"
                    color="primary"
                    onClick={() => this.edit(book.id)}
                  >
                    Edit
                  </Button>
                  <Button
                    size="sm"
                    color="danger"
                    className="ml-1"
                    onClick={() => this.remove(book.id)}
                  >
                    Remove
                  </Button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  };

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderTable(this.state.books)
    );

    return (
      <div>
        <h2>Book List</h2>
        {contents}
      </div>
    );
  }
}

export default withRouter(Books);
