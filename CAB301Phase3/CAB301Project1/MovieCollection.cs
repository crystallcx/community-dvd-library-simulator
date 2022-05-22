// Phase 2
// An implementation of MovieCollection ADT
// 2022


using System;
namespace CAB301Project
{
	//A class that models a node of a binary search tree
	//An instance of this class is a node in a binary search tree 
	public class BTreeNode
	{
		private IMovie movie; // movie
		private BTreeNode lchild; // reference to its left child 
		private BTreeNode rchild; // reference to its right child

		public BTreeNode(IMovie movie)
		{
			this.movie = movie;
			lchild = null;
			rchild = null;
		}

		public IMovie Movie
		{
			get { return movie; }
			set { movie = value; }
		}

		public BTreeNode LChild
		{
			get { return lchild; }
			set { lchild = value; }
		}

		public BTreeNode RChild
		{
			get { return rchild; }
			set { rchild = value; }
		}
	}

	// invariant: no duplicates in this movie collection
	public class MovieCollection : IMovieCollection
	{
		private BTreeNode root; // movies are stored in a binary search tree and the root of the binary search tree is 'root' 
		private int count; // the number of (different) movies currently stored in this movie collection 



		// get the number of movies in this movie colllection 
		// pre-condition: nil
		// post-condition: return the number of movies in this movie collection and this movie collection remains unchanged
		public int Number { get { return count; } }

		// constructor - create an object of MovieCollection object
		public MovieCollection()
		{
			root = null;
			count = 0;
		}

		// Check if this movie collection is empty
		// Pre-condition: nil
		// Post-condition: return true if this movie collection is empty; otherwise, return false.
		public bool IsEmpty()
		{
			return root == null && count == 0;
		}


		// Insert a movie into this movie collection
		// Pre-condition: nil
		// Post-condition: the movie has been added into this movie collection and return true, if the movie is not in this movie collection; otherwise, the movie has not been added into this movie collection and return false.
		public bool Insert(IMovie movie)
		{
			if (root == null)
			{
				root = new BTreeNode(movie);
				Console.WriteLine($" Now Adding {movie.Title} to the MovieCollection");
				count++;
				return true;
			}
			else
			{
				if (Search(movie) == true)
				{
					Console.WriteLine($" Movie: {movie.Title} Already Exists! - Please try again - MOVIE INSERT ERROR");
					return false;
				}
				Insert(movie, root);
				count++;
				return true;
			}
		}

		//private helper function for public insert method, to provide recursion and return back to the public method.
		private void Insert(IMovie thisMovie, BTreeNode pointer)
		{
			if (thisMovie.CompareTo(pointer.Movie) < 0)
			{
				if (pointer.LChild == null)
				{
					pointer.LChild = new BTreeNode(thisMovie);
					Console.WriteLine($" Now Adding {thisMovie.Title} to the Movie Collection");
					return;
				}
				else
					Insert(thisMovie, pointer.LChild);
			}
			else
			{
				if (pointer.RChild == null)
				{
					pointer.RChild = new BTreeNode(thisMovie);
					Console.WriteLine($" Now Adding {thisMovie.Title} to the Movie Collection");
					return;
				}
				else
					Insert(thisMovie, pointer.RChild);
			}
		}


		// Delete a movie from this movie collection
		// Pre-condition: nil
		// Post-condition: the movie is removed out of this movie collection and return true, if it is in this movie collection; return false, if it is not in this movie collection
		public bool Delete(IMovie movie)
		{
			// search for item and its parent
			BTreeNode pointer = root; // search reference pointer
			BTreeNode parent = null; // parent of pointer
			while ((pointer != null) && (movie.CompareTo(pointer.Movie) != 0))
			{
				parent = pointer;
				if (movie.CompareTo(pointer.Movie) < 0) // move to left child of ptr
					pointer = pointer.LChild;
				else
					pointer = pointer.RChild;
			}

			if (pointer != null) // if the search was successful
			{
				// case 3: item has two children
				if ((pointer.LChild != null) && (pointer.RChild != null))
				{
					// find the right-most node in left subtree of ptr
					if (pointer.LChild.RChild == null) //  the right subtree of ptr.LChild is empty
					{
						pointer.Movie = pointer.LChild.Movie;
						pointer.LChild = pointer.LChild.LChild;
						//debug
						//Console.WriteLine($"Deleteing Movie: {movie.Title} - Delete Success");
						count--;
						return true;
					}
					else
					{
						BTreeNode p = pointer.LChild;
						BTreeNode pp = pointer; // parent of p
						while (p.RChild != null)
						{
							pp = p;
							p = p.RChild;
						}
						// copy the item at p to ptr
						pointer.Movie = p.Movie;
						pp.RChild = p.LChild;
						//debug
						//Console.WriteLine($"Deleteing Movie: {movie.Title} - Delete Success");
						count--;
						return true;
					}
				}
				else // item has no or only one child
				{
					BTreeNode c;
					if (pointer.LChild != null)
						c = pointer.LChild;
					else
						c = pointer.RChild;

					// remove node 
					if (pointer == root) // change root
						root = c;
					else
					{
						if (pointer == parent.LChild)
							parent.LChild = c;
						else
							parent.RChild = c;
					}
					//debug
					//Console.WriteLine($"Deleteing Movie: {movie.Title} - Delete Success");
					count--;
					return true;
				}

			}
			Console.WriteLine($"Movie: {movie.Title} does NOT exists. - Delete Error Message.");
			return false;
		}

		// Search for a movie in this movie collection
		// pre: nil
		// post: return true if the movie is in this movie collection;
		//	     otherwise, return false.
		public bool Search(IMovie movie)
		{
			return Search(movie, root);
		}

		//private helper function for the public search function - used for the purpose of recursion. 
		private bool Search(IMovie movie, BTreeNode pointer)
		{
			if (pointer != null)
			{
				if (movie.CompareTo(pointer.Movie) == 0)
				{
					//debug
					//Console.WriteLine($"Movie: {movie.Title} exists! - Search by IMovie object = True");
					return true;
				}
				else
					if (movie.CompareTo(pointer.Movie) < 0)
					return Search(movie, pointer.LChild);
				else
					return Search(movie, pointer.RChild);
			}
			else
			{
				//debug
				//Console.WriteLine($"Movie: {movie.Title} does NOT exists!- Search by IMovie object = False.");
				return false;
			}
		}


		public IMovie Search(string movietitle)
		{
			IMovie result = Search(movietitle, root);
			return result;
		}

		private IMovie Search(string movietitle, BTreeNode r)
		{
			if (r == null) // check twice
				return null;
			// if comparison is lower go left
			if (movietitle.ToLower().CompareTo(r.Movie.Title.ToLower()) == -1)
				return Search(movietitle, r.LChild);
			// if comparison is higher go right
			else if (movietitle.ToLower().CompareTo(r.Movie.Title.ToLower()) == 1)
				return Search(movietitle, r.RChild);
			else
				return r.Movie;
		}

		// Store all the movies in this movie collection in an array in the dictionary order by their titles
		// Pre-condition: nil
		// Post-condition: return an array of movies that are stored in dictionary order by their titles
		public IMovie[] ToArray()
		{
			if (!IsEmpty())
			{
				IMovie[] moviesToArray = new IMovie[count];
				InOrderTraverse(root, moviesToArray, 0);
				return moviesToArray;
			}
			else
			{
				//debug
				//Console.WriteLine("There are no movies in this MovieCollection. - ToArray Search Error.");
				return null;
			}
		}

		//private helper function for ToArray - used for the purpose of filling the temp array, and for the purpose of recursion.
		//Traverses the BST in dictionary order (left to right) and adds each node to the temp array which is returned back to the public ToArray method.
		private int InOrderTraverse(BTreeNode root, IMovie[] tempArray, int index)
		{
			if (root.LChild != null)
			{
				index = InOrderTraverse(root.LChild, tempArray, index);
			}
			tempArray[index++] = root.Movie;
			if (root.RChild != null)
			{
				index = InOrderTraverse(root.RChild, tempArray, index);
			}
			return index; // return the last index
		}


		// Clear this movie collection
		// Pre-condotion: nil
		// Post-condition: all the movies have been removed from this movie collection 
		public void Clear()
		{
			root = null;
			count = 0;
		}
	}
}
