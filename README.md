# Introduction
In my quest to implementing the (dual or simple) depth peeling render
algorithm, I needed to understand in details of blending fragments
back to front or front to back.

# The problem
Let's define a pixel $p$ by the pair $(c, \alpha)$, where $c\in[0,1]$
is the color of the pixel and $\alpha$ is the opacity of the pixel. Such a
pixel is opaque when $\alpha = 1$ and completely transparent when
$\alpha = 0$. If the pixel $p$ is placed in front of a background color
$c_\mathrm{bg}$, then the resulting percieved color $\bar c$ is the sum of the
light coming from the background through $p$ and the light emitted by
$p$ itself:
$$\bar c = \alpha c + (1 - \alpha)c_\mathrm{bg}.$$
